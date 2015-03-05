﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MXTires.Microdata
{
    public class Thing
    {
        [JsonProperty("@context", Order = 1)]
        string context = "http://schema.org";

        [JsonProperty("@type", Order = 2)]
        public string Type { get { return this.GetType().Name; } }

        /// <summary>
        /// URL 	An additional type for the item, typically used for adding more specific types from external vocabularies in microdata syntax. 
        /// This is a relationship between something and a class that the thing is in. In RDFa syntax, it is better to use the native RDFa syntax - the 
        /// 'typeof' attribute - for multiple types. Schema.org tools may have only weaker understanding of extra types, in particular those 
        /// defined externally.
        /// </summary>
        [JsonProperty("additionalType")]
        public string AdditionalType { get; set; }
        /// <summary>
        /// Text 	An alias for the item.
        /// </summary>
        public string AlternateName { get; set; }
        /// <summary>
        /// Text 	A short description of the item.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// URL  to an image of the item. This can be a URL or a fully described ImageObject.
        /// </summary>
        public string Image { get; set; }
        
        /// <summary>
        /// Text 	The name of the item.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Action - Indicates a potential Action, which describes an idealized action in which this thing would play an 'object' role.
        /// </summary>
        [JsonProperty("potentialAction")]
        public Microdata.Action PotentialAction { get; set; }
        /// <summary>
        ///	URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Freebase page, or official website.
        /// </summary>
        public string SameAs { get; set; }
        /// <summary>
        /// URL of the item.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Returns Jason string that  represents current object
        /// </summary>
        /// <returns></returns>
        public string ToJason()
        {
            string item = JsonConvert.SerializeObject(this, Formatting.Indented);
            item = item.Replace("Context", "@context");
            item= item.Replace("Type", "@type");
            return "<script type=\"application/ld+json\">" + item + "</script>";
        }
    }
}