using System;
using System.Collections.Generic;
using TypewiseAlert.AlertTargets;

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

        static Dictionary<AlertTarget, ISendAlert> alertTargets = new Dictionary<AlertTarget, ISendAlert>{

            {AlertTarget.TO_CONTROLLER, new SendToController() },
            {AlertTarget.TO_EMAIL, new SendToEmail() },

        };

        public static bool CheckAndAlert(
            AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC) {

            BreachType breachType = ClassifyTemperatureBreach(batteryChar.coolingType, temperatureInC);

            AlertContext alertContext = new AlertContext();

            alertContext.SetTarget(alertTargets[alertTarget]);

            alertContext.SetBreachType(breachType);

            alertContext.Send();

            return alertContext.sent;


        }

    }
}
