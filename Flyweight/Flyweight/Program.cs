using System;
using System.Collections.Generic;

namespace Flyweight
{
    public enum EBodyType { EH_BA, EH_BB, EH_BC };
    public enum ELensType { EH_L1, EH_L2, EH_L3 };
    public enum ELightType { LT_CLEAR, LT_CLOUDY, LT_LAMP };

    class Meta
    {
        static readonly string[] bodyname = { "EH_BA", "EH_BB", "EH_BC" };
        static readonly string[] lensname = { "EL_L1", "EH_L2", "EH_L3" };
        static readonly string[] lightname = { "맑음", "흐림", "램프" };

        public EBodyType Body { get; private set; }
        public ELensType Lens { get; private set; }
        public ELightType Light { get; private set; }

        readonly int seq;
        static int scnt;

        public Meta(EBodyType eBody, ELensType eLens, ELightType eLight)
        {
            scnt++;
            seq = scnt;
            Body = eBody;
            Lens = eLens;
            Light = eLight;
        }

        public bool isEqual(EBodyType bodyType, ELensType lensType, ELightType lightType)
        {
            return (bodyType == Body) && (lensType == Lens) && (Light == lightType);
        }

        public void View()
        {
            Console.WriteLine("일련번호:{0}", seq);
            Console.WriteLine("Body:{0}", bodyname[(int)Body]);
            Console.WriteLine("Lens:{0}", bodyname[(int)Lens]);
            Console.WriteLine("Light:{0}", bodyname[(int)Light]);
        }
    }

    class MetaPool
    {
        List<Meta> metas = new List<Meta>();

        public static MetaPool Singleton { get; private set; }

        static MetaPool()
        {
            Singleton = new MetaPool();
        }

        private MetaPool()
        {
            
        }

        public Meta MakeMeta(EBodyType bodyType, ELensType lensType, ELightType lightType)
        {
            foreach (var meta in metas)
            {
                if (meta.isEqual(bodyType, lensType, lightType))
                {
                    return meta;
                }
            }

            Meta m = new Meta(bodyType, lensType, lightType);
            metas.Add(m);
            return m;
        }
    }

    class PictureFile
    {
        string name;
        Meta meta;
        public PictureFile(string name, EBodyType bodyType, ELensType lensType, ELightType lightType)
        {
            MetaPool meta_pool = MetaPool.Singleton;
            meta = meta_pool.MakeMeta(bodyType, lensType, lightType);
        }
        public void View()
        {
            Console.WriteLine("사진 이름:{0}", name);
            meta.View();
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            EBodyType bodyType = EBodyType.EH_BA;
            ELensType lensType = ELensType.EH_L1;
            ELightType lightType = ELightType.LT_CLEAR;

            PictureFile pictureFile = new PictureFile("사진", bodyType, lensType, lightType);
            PictureFile pictureFile2 = new PictureFile("사진", bodyType, lensType, lightType);

            pictureFile.View();
            pictureFile2.View();
        }
    }
}
