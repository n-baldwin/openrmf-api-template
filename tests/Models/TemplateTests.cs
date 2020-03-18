using Xunit;
using openrmf_templates_api.Models;
using System;
using MongoDB.Bson;

namespace tests.Models
{
    public class TemplateTests
    {
        [Fact]
        public void Test_NewTemplateIsValid()
        {
            Template template = new Template();

            // Testing
            Assert.False(template == null);
        }
    
        [Fact]
        public void Test_TemplateWithDataIsValid()
        {
            Template template = new Template();

            template.created = DateTime.Now;
            template.description = "description";
            template.rawChecklist = "raw";
            template.stigType = "type";
            template.stigRelease = "release";
            template.stigDate = "date";
            template.stigId = "ID";
            template.title = "title";
            template.version = "1";
            template.filename = "filename.txt";
            template.InternalId = ObjectId.GenerateNewId();
            template.updatedOn = DateTime.Now;
            template.createdBy = Guid.NewGuid();
            template.updatedBy = Guid.NewGuid();

            // Testing
            Assert.True(template.description == "description");
            Assert.True(template.rawChecklist == "raw");
            Assert.True(template.stigType == "type");
            Assert.True(template.stigRelease == "release");
            Assert.True(template.stigDate == "date");
            Assert.True(template.stigId == "ID");
            Assert.True(template.title == "title");
            Assert.True(template.version == "1");
            Assert.True(template.filename == "filename.txt");
            Assert.True(template.templateType == "USER");
            Assert.False(template.created == null);
            Assert.False(template.updatedOn == null);
            Assert.False(template.createdBy == null);
            Assert.False(template.updatedBy == null);
            Assert.False(template.InternalId == null);
            Assert.False(template.CHECKLIST == null);
        }
    }
}
