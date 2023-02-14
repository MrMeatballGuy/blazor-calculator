using AngleSharp.Diffing.Extensions;
using AngleSharp.Dom;
using BlazorCalculator.Pages;
using Bunit;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class ClearButtonTest
    {
        private TestContext ctx;
        private IRenderedComponent<Calculator> calculatorComponent;
        private IElement inputOne;
        private IElement inputTwo;
        private IElement resultInput;
        public ClearButtonTest()
        {
            this.ctx = new TestContext();
            this.calculatorComponent = ctx.RenderComponent<Calculator>();
            this.inputOne = calculatorComponent.Find("#first-num");
            this.inputTwo = calculatorComponent.Find("#second-num");
            this.resultInput = calculatorComponent.Find("#result");
        }

        [Fact]
        public void TestClearButtonSuccess()
        {
            // Arrange
            var expectedResult = "";
            
            inputOne.Change(2);
            inputTwo.Change(4);
            resultInput.Change(8);

            var btn = calculatorComponent.Find("#clr-btn");
            btn.Click();

            string inputOneValue = "";
            string inputTwoValue = "";
            string outputResultValue = "";
            inputOne.TryGetAttrValue("value", out inputOneValue);
            inputOne.TryGetAttrValue("value", out inputTwoValue);

            resultInput.TryGetAttrValue("value", out outputResultValue);

            // Assert
            Assert.Equal(expectedResult, inputOneValue);
            Assert.Equal(expectedResult, inputTwoValue);
            Assert.Equal(expectedResult, outputResultValue);
        }
    }
}

