using System;
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
        public void SendToEmailTests()
        {
            Assert.True(TypewiseAlert.SendToEmail(BreachType.TOO_HIGH) == true);
            Assert.True(TypewiseAlert.SendToEmail(BreachType.TOO_LOW) == true);
            Assert.True(TypewiseAlert.SendToEmail(BreachType.NORMAL) == true);
        }
    }
}
