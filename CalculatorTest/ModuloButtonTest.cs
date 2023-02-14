using AngleSharp.Diffing.Extensions;
using AngleSharp.Dom;
using BlazorCalculator;
using BlazorCalculator.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
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
            this.ctx.Services.AddScoped<ICustomMath, CustomMath>();
            this.calculatorComponent = ctx.RenderComponent<Calculator>();
            this.inputOne = calculatorComponent.Find("#first-num");
            this.inputTwo = calculatorComponent.Find("#second-num");
            this.resultInput = calculatorComponent.Find("#result");
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 8)]
        
        public void TestModuloButtonSuccess(double firstNumber, double secondNumber)
        {
            // Arrange
            var expectedResult = firstNumber % secondNumber;

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

            string expectedResult = "Input string was not in a correct format.";
            btn.Click();

            string output = "";
            resultInput.TryGetAttrValue("value", out output);

            // Assert
            Assert.Equal(expectedResult, output);
        }
    }
}

