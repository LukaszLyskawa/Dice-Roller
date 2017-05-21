using Dice_Roller;
using Dice_Roller.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class StringParserTests
    {
        {
            return $"{amount}d{sides}{Enum.GetName(typeof(DropKeepType), operationType)}{operationAmount}{modifier>=0?"+":"-"}{modifier}";
        }
        
        const int amount=3;
        const int sides=8;
        const DropKeepType operationType = DropKeepType.hl;
        const int operationAmount = 2;
        const int modifier = 1;


        [TestMethod]
        public void TestStringParser()
        {
            var roll = StringParser.Parse(ROLLSTRING);

            Assert.IsTrue(roll.amount == amount);
            Assert.IsTrue(roll.DiceSides == sides);
            Assert.IsTrue(roll.modifier == modifier);
            Assert.IsTrue(roll.operationType == operationType);
        }

        [TestMethod]
        public void TestStringParserExt()
        {
            var roll = ROLLSTRING.ParseRoll();

            Assert.IsTrue(roll.amount == amount);
            Assert.IsTrue(roll.DiceSides == sides);
            Assert.IsTrue(roll.modifier == modifier);
            Assert.IsTrue(roll.operationType == operationType);
        }
    }
}
