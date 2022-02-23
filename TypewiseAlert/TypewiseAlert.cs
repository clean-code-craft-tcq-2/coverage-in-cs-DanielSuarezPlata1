using System;
using System.Collections.Generic;

namespace TypewiseAlert
{
    public partial class TypewiseAlert
    {
        public enum BreachType {
            NORMAL,
            TOO_LOW,
            TOO_HIGH
        };

        static Dictionary<CoolingType, CoolingLimits> CoolingOptions = new Dictionary<CoolingType, CoolingLimits>{

            {CoolingType.PASSIVE_COOLING,new CoolingLimits{lowerLimit= 0,upperLimit=35 } },

            {CoolingType.HI_ACTIVE_COOLING,new CoolingLimits{lowerLimit= 0,upperLimit=45 } },

            {CoolingType.MED_ACTIVE_COOLING,new CoolingLimits{lowerLimit= 0,upperLimit=40 } },

        };

        public static BreachType InferBreach(double value, double lowerLimit, double upperLimit) {

            if(value < lowerLimit) {
            return BreachType.TOO_LOW;
            }

            if(value > upperLimit) {
            return BreachType.TOO_HIGH;
            }

            return BreachType.NORMAL;

        }

        public enum CoolingType {
            PASSIVE_COOLING,
            HI_ACTIVE_COOLING,
            MED_ACTIVE_COOLING
        };

        public static BreachType ClassifyTemperatureBreach(
            CoolingType coolingType, double temperatureInC) {

            int lowerLimit = CoolingOptions[coolingType].lowerLimit; 
            int upperLimit = CoolingOptions[coolingType].upperLimit;

            return InferBreach(temperatureInC, lowerLimit, upperLimit);

        }
        public enum AlertTarget{
            TO_CONTROLLER,
            TO_EMAIL
        };

        public struct BatteryCharacter {
            public CoolingType coolingType;
            public string brand;
        }


        public static void CheckAndAlert(
            AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC) {

            BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);

            switch(alertTarget) {

                case AlertTarget.TO_CONTROLLER:
                    SendToController(breachType);
                    break;

                case AlertTarget.TO_EMAIL:
                    SendToEmail(breachType);
                    break;

            }

        }
        public static void SendToController(BreachType breachType) {

            const ushort header = 0xfeed;

            Console.WriteLine("{} : {}\n", header, breachType);

        }

        static Dictionary<BreachType, ISendEmail> breachAlerters = new Dictionary<BreachType, ISendEmail>{

            {BreachType.TOO_LOW, new EmailLowTemperature() },
            {BreachType.TOO_HIGH, new EmailHighTemparature() },
            {BreachType.NORMAL, new EmailLowTemperature() },

        };

        public static bool SendToEmail(BreachType breachType) {

            string recepient = "a.b@c.com";

            EmailContext emailContext = new EmailContext();

            emailContext.SetBreachAlerter(breachAlerters[breachType]);

            emailContext.SetRecepient(recepient);

            emailContext.Send();

            return emailContext.sent;

        }

    }
}
