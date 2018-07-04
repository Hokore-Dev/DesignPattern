using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface Command
    {
        void Execute();
    }

    public class Light
    {
        public void On()
        {

        }
    }

    public class LightOnCommand : Command
    {
        Light light;

        public LightOnCommand(Light inLight)
        {
            this.light = inLight;
        }

        public void Execute()
        {
            light.On();
        }
    }

    public class SimpleRemoteControl
    {
        Command slot;

        public void SetCommand(Command inSlot)
        {
            slot = inSlot;
        }

        public void ButtonWasPressd()
        {
            slot.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleRemoteControl remote = new SimpleRemoteControl();
            Light light = new Light();
            LightOnCommand lightOn = new LightOnCommand(light);

            remote.SetCommand(lightOn);
            remote.ButtonWasPressd();
        }
    }
}
