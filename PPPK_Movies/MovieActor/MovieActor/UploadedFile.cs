//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieActor
{
    using System;
    using System.Collections.Generic;
    
    public partial class UploadedFile
    {
        public int IDUploadedFile { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int MovieIDMovie { get; set; }
    
        public virtual Movie Movie { get; set; }
    }
}
