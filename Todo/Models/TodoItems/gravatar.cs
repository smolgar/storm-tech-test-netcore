using System;
using Newtonsoft.Json;

namespace Todo.Models.TodoItems
{

    public partial class GravatarUserModel
    {
        [JsonProperty("entry")]
        public Entry[] Entry { get; set; }
    }

    public partial class Entry
    {

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("requestHash")]
        public string RequestHash { get; set; }

        [JsonProperty("profileUrl")]
        public Uri ProfileUrl { get; set; }

        [JsonProperty("preferredUsername")]
        public string PreferredUsername { get; set; }

        [JsonProperty("thumbnailUrl")]
        public Uri ThumbnailUrl { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("urls")]
        public object[] Urls { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("formatted")]
        public string Formatted { get; set; }
    }

    public partial class Photo
    {
        [JsonProperty("value")]
        public Uri Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

