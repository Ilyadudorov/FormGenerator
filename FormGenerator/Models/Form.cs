using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Models
{

    //public class ValidationRule
    //{
    //    [JsonProperty("type")]
    //    public string Type { get; set; }
    //}

    public class Attributes
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        //[JsonProperty("name")]
        //public string Name { get; set; }
        //[JsonProperty("placeholder")]
        //public string Placeholder { get; set; }
        //[JsonProperty("required")]
        //public bool? Required { get; set; }
        //[JsonProperty("value")]
        //public string Value { get; set; }
        //[JsonProperty("label")]
        //public string Label { get; set; }
        //[JsonProperty("class")]
        //public string Class { get; set; }
        //[JsonProperty("validationRules")]
        //public List<ValidationRule> ValidationRules { get; set; }
        //[JsonProperty("disabled")]
        //public bool? Disabled { get; set; }
        //[JsonProperty("checked")]
        //public bool? Checked { get; set; }
    }

    public class Item
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("attributes")]

        public Attributes Attributes { get; set; }
    }

    public class Form
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("postmessage")]
        public string Postmessage { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    //public class Root
    //{
    //    public Form Form { get; set; }
    //}
}
