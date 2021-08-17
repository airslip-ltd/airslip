using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Airslip.Tests
{
    public class ConfigurationTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public ConfigurationTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        [Fact]
        public void Can_generate_descriptor_suffix()
        {
            Stopwatch timer = Stopwatch.StartNew();

            string statementDescriptorSuffix = Configuration.GenerateStatementDescriptorSuffix();

            _outputHelper.WriteLine(
                "Generating the statement descriptor {0} took {1}ms", 
                statementDescriptorSuffix,
                timer.ElapsedMilliseconds);

            statementDescriptorSuffix.Should().StartWith("_");
            statementDescriptorSuffix.Length.Should().Be(6);
        }

        [Fact]
        public void Generating_100_statement_descriptors_does_not_clash()
        {
            List<string> statementDescriptorSuffixes = new(); 
            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                statementDescriptorSuffixes.Add(Configuration.GenerateStatementDescriptorSuffix());
            }

            statementDescriptorSuffixes.Distinct().Count().Should().Be(statementDescriptorSuffixes.Count);
            
            _outputHelper.WriteLine(
                "Generating the statement descriptors took {0}ms", 
                timer.ElapsedMilliseconds);
        }
    }
}