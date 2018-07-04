using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    abstract class Expression
    {
        public Expression Next
        {
            get;
            set;
        }
        public Expression()
        {
            Next = null;
        }
        public abstract string Interpret(string context);
        public virtual void DoItWithPicture(Picture picture)
        {
            if (Next != null)
            {
                Next.DoItWithPicture(picture);
            }
        }
        protected string NextInterpret(string context)
        {
            if (Next != null)
            {
                return Next.Interpret(context);
            }
            return context;
        }
        protected int GetNumber(string context, int index)
        {
            int index2 = -1;
            index2 = context.IndexOf(";", index);
            string re = context.Substring(index + 1, index2 - index - 1);
            try
            {
                return int.Parse(re);
            }
            catch { }
            return 0;
        }
    }

    class ToneExpression : Expression
    {
        int value;
        public override string Interpret(string context)
        {
            value = 0;
            int index = -1;
            string be = "";
            string af = "";
            while ((index = context.IndexOf("T")) != -1)
            {
                value += GetNumber(context, index);
                if (index > 0)
                {
                    be = context.Substring(0, index);
                }
                else
                {
                    be = "";
                }
                index = context.IndexOf(";", index);
                af = context.Substring(index + 1);
                context = be + af;
            }
            return NextInterpret(context);
        }
        public override void DoItWithPicture(Picture picture)
        {
            picture.ChangeTone(value);
            base.DoItWithPicture(picture);
        }
    }

    class BrighExpression : Expression
    {
        int value;
        public override string Interpret(string context)
        {
            value = 0;
            int index = -1;
            string be = "";
            string af = "";
            while ((index = context.IndexOf("B")) != -1)
            {
                value += GetNumber(context, index);
                if (index > 0)
                {
                    be = context.Substring(0, index);
                }
                else
                {
                    be = "";
                }
                index = context.IndexOf(";", index);
                af = context.Substring(index + 1);
                context = be + af;
            }
            return NextInterpret(context);
        }
        public override void DoItWithPicture(Picture picture)
        {
            picture.ChangeBrightness(value);
            base.DoItWithPicture(picture);
        }
    }

    class SatuExpression : Expression
    {
        int value;
        public override string Interpret(string context)
        {
            value = 0;
            int index = -1;
            string be = "";
            string af = "";
            while ((index = context.IndexOf("S")) != -1)
            {
                value += GetNumber(context, index);
                if (index > 0)
                {
                    be = context.Substring(0, index);
                }
                else
                {
                    be = "";
                }
                index = context.IndexOf(";", index);
                af = context.Substring(index + 1);
                context = be + af;
            }
            return NextInterpret(context);
        }
        public override void DoItWithPicture(Picture picture)
        {
            picture.ChangeSaturation(value);
            base.DoItWithPicture(picture);
        }
    }
}
