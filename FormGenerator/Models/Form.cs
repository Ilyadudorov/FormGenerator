using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Models
{
    public class Form
    {
        public string name { get; set; }
        [JsonProperty("postmessage")]
        public string Postmessage { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        public class Item
        {
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("attributes")]
            public Attributes attributes { get; set; }
        }
    }

    

    public class Attributes
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
        [JsonProperty("required")]
        public bool? Required { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("class")]
        public string Class { get; set; }
        [JsonProperty("validationRules")]
        public List<ValidationRule> ValidationRules { get; set; }
        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
        [JsonProperty("checked")]
        public bool? Checked { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("options")]
        public List<Options> Options { get; set; }

        [JsonProperty("items")]
        public List<Radioitems> Radioitems { get; set; }
    }

    public class ValidationRule
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Options
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }

    public class Radioitems
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("checked")]
        public bool Checked { get; set; }
    }

}
