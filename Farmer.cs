using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FamerGameGUI
{
    class Farmer
    {
        ArrayList northBank = new ArrayList();
        ArrayList southBank = new ArrayList();
        Direction farmer;


        public enum Direction
        {
            North,
            South
        }

        public Farmer()
        {

            northBank.Add("FOX");
            northBank.Add("CHICKEN");
            northBank.Add("GRAIN");

            farmer = Direction.North;
        }

        public bool TheFarmer
        {
            get
            {
                switch(farmer)
                {
                    case Direction.North:
                        return true;
                    case Direction.South:
                        return false;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public string Move(string item)
        {

            string result = "No Error";

            switch (item)
            {
                case "CHICKEN":
                    if ((farmer == Direction.North) && (northBank.Contains("CHICKEN")))
                    {
                        northBank.Remove("CHICKEN");
                        southBank.Add("CHICKEN");
                        farmer = Direction.South;
                    }
                    else if ((farmer == Direction.South) && (southBank.Contains("CHICKEN")))
                    {
                        southBank.Remove("CHICKEN");
                        northBank.Add("CHICKEN");
                        farmer = Direction.North;
                    }

                    else
                        result = "Error";
                    break;

                case "FOX":
                    if ((farmer == Direction.North) && (northBank.Contains("FOX")))
                    {
                        northBank.Remove("FOX");
                        southBank.Add("FOX");
                        farmer = Direction.South;
                    }
                    else if ((farmer == Direction.South) && (southBank.Contains("FOX")))
                    {
                        southBank.Remove("FOX");
                        northBank.Add("FOX");
                        farmer = Direction.North;
                    }

                    else
                        result = "Error";
                    break;

                case "GRAIN":
                    if ((farmer == Direction.North) && (northBank.Contains("GRAIN")))
                    {
                        northBank.Remove("GRAIN");
                        southBank.Add("GRAIN");
                        farmer = Direction.South;
                    }

                    else if ((farmer == Direction.South) && (southBank.Contains("GRAIN")))
                    {
                        southBank.Remove("GRAIN");
                        northBank.Add("GRAIN");
                        farmer = Direction.North;
                    }
                    else
                        result = "Error";
                    break;

                case "":
                    if (farmer == Direction.North)
                    {
                        farmer = Direction.South;
                    }
                    else
                        farmer = Direction.North;

                    break;
            }
            return result;

        }


        public bool DetermineWin()
        {
            bool result = false;

            if ((southBank.Contains("CHICKEN")) && (southBank.Contains("FOX")) && (southBank.Contains("GRAIN")))
                result = true;
            return result;
        }

        public string AnimalAteFood()
        {
            string result = "Not Eaten";

            if (farmer == Direction.North)
            {
                if (southBank.Contains("CHICKEN") && (southBank.Contains("FOX")))
                    result = "FOX ate CHICKEN";
                else if (southBank.Contains("CHICKEN") && (southBank.Contains("GRAIN")))
                    result = "CHICKEN ate GRAIN";


            }
            if (farmer == Direction.South)
            {
                if (northBank.Contains("CHICKEN") && (northBank.Contains("FOX")))
                    result = "FOX ate CHICKEN";
                else if (northBank.Contains("CHICKEN") && (northBank.Contains("GRAIN")))
                    result = "CHICKEN ate GRAIN";


            }
            return result;
        }


        public string NorthBank
        {
            get
            {
                string riverBank = " ";
                foreach (Object obj in northBank)
                    riverBank = riverBank + " " + obj + " ";


                return riverBank;
            }
        }


        public string SouthBank
        {
            get
            {
                string riverBank = " ";
                foreach (Object obj in southBank)
                    riverBank = riverBank + " " + obj + " ";


                return riverBank;
            }

        }
        public void ResetGame()
        {
            northBank.Clear();
            northBank.Add("FOX");
            northBank.Add("CHICKEN");
            northBank.Add("GRAIN");

            farmer = Direction.North;
            southBank.Clear();


        }
    }
}
