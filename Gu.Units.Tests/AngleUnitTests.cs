namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class AngleUnitTests
    {
        private static readonly TestCase[] HappyPathSource =
        {
            new TestCase("�", "\u00B0"),
            new TestCase("\u00B0", "\u00B0"),
        };

        [TestCaseSource(nameof(HappyPathSource))]
        public void ParseSuccess(TestCase testCase)
        {
            var unit = AngleUnit.Parse(testCase.Text);
            Assert.AreEqual(testCase.Expected, unit.ToString());
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public void TryParseSuccess(TestCase testCase)
        {
            Assert.AreEqual(true, AngleUnit.TryParse(testCase.Text, out AngleUnit result));
            Assert.AreEqual(testCase.Expected, result.ToString());
        }

        public class TestCase
        {
            public TestCase(string text, string expected)
            {
                this.Text = text;
                this.Expected = expected;
            }

            public string Text { get; }

            public string Expected { get; }

            public override string ToString()
            {
                return $"{nameof(this.Text)}: {this.Text}, {nameof(this.Expected)}: {this.Expected}";
            }
        }
    }
}