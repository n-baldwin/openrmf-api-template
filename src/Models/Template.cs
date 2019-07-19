using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace openrmf_templates_api.Models
{
    [Serializable]
    public class Template
    {
        public Template () {
            CHECKLIST = new CHECKLIST();
        }

        public DateTime created { get; set; }
        public string description { get; set; }
        public CHECKLIST CHECKLIST { get; set; }
        public string rawChecklist { get; set; }
        public string stigType { get; set; }
        public string stigRelease { get; set; }
        public string title { get {
            return "Template-" + stigType.Trim() + "-" + stigRelease.Trim();
        }}        
        
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }

        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime? updatedOn { get; set; }

        public Guid createdBy { get; set; }
        public Guid? updatedBy { get; set; }
    }

}