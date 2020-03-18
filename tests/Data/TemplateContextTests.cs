using Xunit;
using System;
using openrmf_templates_api.Data;
using openrmf_templates_api.Models;
using Microsoft.Extensions.Options;

namespace tests.Data
{
    public class TemplateContextTests
    {
        private readonly TemplateContext _templateContext;

        public TemplateContextTests()
        {
            Settings settings = new Settings();

            settings.ConnectionString = "mongodb://openrmftemplate:openrmf1234!@localhost/openrmf?authSource=admin";
            settings.Database = "openrmftemplate";

            _templateContext = new TemplateContext(Options.Create<Settings>(settings));
        }

        [Fact]
        public void Test_TemplateContextIsValid()
        {
            // Testing
            Assert.False(_templateContext.Templates == null);
        }
    }
}
