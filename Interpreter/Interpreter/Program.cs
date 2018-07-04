using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Picture
    {
        string name;
        int tone;
        int brightness;
        int saturation;
        public Picture(string name, int tone, int brightness, int saturation)
        {
            this.name = name;
            this.tone = tone;
            this.brightness = brightness;
            this.saturation = saturation;
        }
        public void ChangeTone(int tone)
        {
            this.tone += tone;
        }
        public void ChangeBrightness(int brightness)
        {
            this.brightness += brightness;
        }
        public void ChangeSaturation(int saturation)
        {
            this.saturation += saturation;
        }
        public void View()
        {
            Console.WriteLine("사진 파일명:{0}", name);
            Console.WriteLine("    색조:{0} 명도:{1} 채도:{2}",
                tone, brightness, saturation);
        }
    }

    class Macro
    {
        Expression head = null;
        Expression tail = null;
        public void AddExpression(Expression expression)
        {
            if (head != null)
            {
                tail.Next = expression;
                tail = expression;
            }
            else
            {
                head = tail = expression;
            }
        }
        public void ChangePicture(Picture picture)
        {
            head.DoItWithPicture(picture);
        }
        public void AddContext(string context)
        {
            head.Interpret(context);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Expression ex1 = new ToneExpression();
            Expression ex2 = new BrighExpression();
            Expression ex3 = new SatuExpression();
            Macro macro = new Macro();
            macro.AddExpression(ex1);
            macro.AddExpression(ex2);
            macro.AddExpression(ex3);
            macro.AddContext("B 20 ;");
            macro.AddContext("B 20 ;T-12 ; S 10 ; B10 ;");
            Picture picture = new Picture("현충사의 봄", 100, 100, 100);
            macro.ChangePicture(picture);
            picture.View();
        }
    }
}
