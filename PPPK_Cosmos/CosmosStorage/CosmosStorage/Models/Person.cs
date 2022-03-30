using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmosStorage.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "firstName")]
        public string First_Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastName")]
        public string Last_Name { get; set; }
        public bool Adult { get; set; }
    }
}