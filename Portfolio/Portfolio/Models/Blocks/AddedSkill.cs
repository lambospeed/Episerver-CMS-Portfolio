using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Portfolio.Models.Blocks
{
    [ContentType(DisplayName = "Added Skill", GUID = "26c77ce8-e95a-4870-ab3c-33c146406531", AvailableInEditMode = false)]
    public class AddedSkill : BlockData
    {
        public virtual string Skill { get; set; }
    }
}