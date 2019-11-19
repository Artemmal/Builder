using System;
using System.Text;

namespace HW22._3
{
    class Engine
    {
        public string TypeOfEngine { get; set; }
        public Engine(string type)
        {
            TypeOfEngine = type;
        }
    }
    class Wings
    {
        
    }
    class Parts
    {
        public string TypeOfParts { get; set; }
        public Parts(string type)
        {
            TypeOfParts = type;
        }
    }
    class Aircraft
    {
        public Engine Engine { get; set; }
        public Wings Wings { get; set; }
        public Parts Parts { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Engine != null)
            {
                sb.Append(Engine.TypeOfEngine + "\n");
            }
            if (Wings != null)
            {
                sb.Append("Wings \n");
            }
            if (Parts != null)
            {
                sb.Append(Parts.TypeOfParts + "\n");
            }
            return sb.ToString();
        }
    }

    abstract class AircraftBuilder
    {
        public Aircraft Aircraft { get; private set; }
        public void CreateAircraft()
        {
            Aircraft = new Aircraft();
        }
        public abstract void SetEngine();
        public abstract void SetWings();
        public abstract void SetParts();
    }
    class DeltaplanBuilder : AircraftBuilder
    {
        public override void SetEngine()
        {
            this.Aircraft.Engine = new Engine("Engine for deltaplans");
        }
        public override void SetWings()
        {
            this.Aircraft.Wings = new Wings();
        }
        public override void SetParts()
        {
            this.Aircraft.Parts = new Parts("Parts for deltaplan");
        }
    }
    class PlanerBuilder : AircraftBuilder
    {
        public override void SetEngine()
        {
            this.Aircraft.Engine = new Engine("Engine for planers");
        }
        public override void SetWings()
        {
            this.Aircraft.Wings = new Wings();
        }
        public override void SetParts()
        {
            this.Aircraft.Parts = new Parts("Parts for planers");
        }
    }

    class Director
    {
        public Aircraft Construct(AircraftBuilder aircraftBuilder)
        {
            aircraftBuilder.CreateAircraft();
            aircraftBuilder.SetEngine();
            aircraftBuilder.SetWings();
            aircraftBuilder.SetParts();
            return aircraftBuilder.Aircraft;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            AircraftBuilder builder = new DeltaplanBuilder();
            Aircraft deltaplan = director.Construct(builder);
            Console.WriteLine(deltaplan.ToString());
            Console.WriteLine("");
            builder = new PlanerBuilder();
            Aircraft planer = director.Construct(builder);
            Console.WriteLine(planer.ToString());
        }
    }
}
