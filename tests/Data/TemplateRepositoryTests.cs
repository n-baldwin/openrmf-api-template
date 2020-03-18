using Xunit;
using System;
using System.Threading.Tasks;
using openrmf_templates_api.Data;
using openrmf_templates_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace tests.Data
{
    public class TemplateRepositoryTests
    {
        private readonly TemplateRepository _templateRepository;

        public TemplateRepositoryTests()
        {
            Settings settings = new Settings();

            settings.ConnectionString = "mongodb://openrmftemplate:openrmf1234!@localhost/openrmftemplate?authSource=admin";
            settings.Database = "openrmftemplate";

            _templateRepository = new TemplateRepository(Options.Create<Settings>(settings));
        }

        [Fact]
        public async Task Test_TemplateRepositoryIsValid()
        {
            Template template = new Template();
            ObjectId objId = ObjectId.GenerateNewId();

            template.InternalId = objId;

            // Testing
            await _templateRepository.GetAllTemplates();
            await _templateRepository.GetTemplate("someid");
            await _templateRepository.GetTemplate("body", DateTime.Now, 256);
            await _templateRepository.AddTemplate(template);
            await _templateRepository.UpdateTemplate(objId.ToString(), template);
            await _templateRepository.GetLatestTemplate("title");
            await _templateRepository.CountUserTemplates();
            await _templateRepository.CountSystemTemplates();
            await _templateRepository.RemoveTemplate(objId.ToString());
            await _templateRepository.RemoveSystemTemplates();
        }
    }
}
