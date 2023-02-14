using AngleSharp.Diffing.Extensions;
using AngleSharp.Dom;
using BlazorCalculator.Pages;
using Bunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class ModuloButtonTest
    {
        private TestContext ctx;
        private IRenderedComponent<Calculator> calculatorComponent;
        private IElement inputOne;
        private IElement inputTwo;
        private IElement resultInput;
        public ModuloButtonTest()
        {
            this.ctx = new TestContext();
            this.calculatorComponent = ctx.RenderComponent<Calculator>();
            this.inputOne = calculatorComponent.Find("#first-num");
            this.inputTwo = calculatorComponent.Find("#second-num");
            this.resultInput = calculatorComponent.Find("#result");
        }

        [Theory]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        [InlineData(4, 4)]
        
        public void TestModuloButtonSuccess(int firstNumber, int secondNumber)
        {
            // Arrange
            var expectedResult = secondNumber % firstNumber;

            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);

            var btn = calculatorComponent.Find("#mod-btn");
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, Convert.ToDouble(output));
        }

        [Theory]
        [InlineData("a", "b")]
        public void TestModuloButtonFail(string firstNumber, string secondNumber)
        {
            inputOne.Change(firstNumber);
            inputTwo.Change(secondNumber);
            var btn = calculatorComponent.Find("#mod-btn");

            // Assert
            Assert.Throws<FormatException>(() =>
            {
                btn.Click();
            });
        }
    }
}

