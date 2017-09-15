using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Portfolio.Models.Blocks
{
    [ContentType(DisplayName = "AddedProfileInfo", GUID = "48cc3f91-23c5-4c26-8703-2c07bce86cd0", AvailableInEditMode = false)]
    public class AddedHeader : BlockData
    {
        public virtual string PersonImage { get; set; }

        [Display(Name = "Full Name")]
        public virtual string FullName { get; set; }


        public virtual string Headline { get; set; }

        public virtual string Address { get; set; }

        public virtual string LineOfBusiness { get; set; }

        public virtual string Summary { get; set; }

    }
}