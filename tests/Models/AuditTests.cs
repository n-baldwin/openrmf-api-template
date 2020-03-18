using Xunit;
using System;
using openrmf_templates_api.Models;

namespace tests.Models
{
    public class AuditTests
    {
        [Fact]
        public void Test_NewAuditIsValid()
        {
            Audit audit = new Audit();

            // Testing
            Assert.False(audit == null);
            Assert.False(audit.auditId == null);
        }

        [Fact]
        public void Test_AuditWithDataIsValid()
        {
            Audit audit = new Audit();

            audit.program = "aprogram";
            audit.created = DateTime.Now;
            audit.action = "anaction";
            audit.userid = "userid";
            audit.username = "username";
            audit.fullname = "fullname";
            audit.email = "anemail@someplace.com";
            audit.url = "http://awebsite.net";
            audit.message = "This is a very sophisticated message.";

            // Testing
            Assert.True(audit.program == "aprogram");
            Assert.True(audit.action == "anaction");
            Assert.True(audit.userid == "userid");
            Assert.True(audit.username == "username");
            Assert.True(audit.fullname == "fullname");
            Assert.True(audit.email == "anemail@someplace.com");
            Assert.True(audit.url == "http://awebsite.net");
            Assert.True(audit.message == "This is a very sophisticated message.");
        }
    }
}
