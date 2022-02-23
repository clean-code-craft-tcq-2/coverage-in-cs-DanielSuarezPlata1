using System;
using System.Collections.Generic;
using TypewiseAlert.AlertTargets;
using Xunit;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLimits()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 20, 30) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.InferBreach(33, 20, 30) == TypewiseAlert.BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.InferBreach(26, 20, 30) == TypewiseAlert.BreachType.NORMAL);
        }

        [Fact]
        public void InfersBreachAsCoolingType()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, -1) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 36) == TypewiseAlert.BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);

            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, -1) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 46) == TypewiseAlert.BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);

            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, -1) == TypewiseAlert.BreachType.TOO_LOW);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 41) == TypewiseAlert.BreachType.TOO_HIGH);
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 24) == TypewiseAlert.BreachType.NORMAL);
        }

        [Fact]
        public void SendAlertsToEmailTests()
        {
            AlertContext alertContext = new AlertContext();

            alertContext.SetTarget(new SendToEmail());

            // Testing Email with Breach type TOO_HIGH
            alertContext.SetBreachType(BreachType.TOO_HIGH);

            alertContext.Send();

            Assert.True(alertContext.sent == true);

            // Testing Email with Breach type TOO_LOW
            alertContext.SetBreachType(BreachType.TOO_LOW);

            alertContext.Send();

            Assert.True(alertContext.sent == true);

            // Testing Email with Breach type NORMAL
            alertContext.SetBreachType(BreachType.NORMAL);

            alertContext.Send();

            Assert.True(alertContext.sent == true);

        }

        [Fact]
        public void SendAlertsToControllerTests()
        {
            AlertContext alertContext = new AlertContext();

            alertContext.SetTarget(new SendToController());

            // Testing controller with Breach type TOO_HIGH
            alertContext.SetBreachType(BreachType.TOO_HIGH);

            alertContext.Send();

            Assert.True(alertContext.sent == true);

            // Testing controller with Breach type TOO_LOW
            alertContext.SetBreachType(BreachType.TOO_LOW);

            alertContext.Send();

            Assert.True(alertContext.sent == true);

            // Testing controller with Breach type NORMAL
            alertContext.SetBreachType(BreachType.NORMAL);

            alertContext.Send();

            Assert.True(alertContext.sent == true);

        }
    }
}
