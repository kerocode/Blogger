using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blogger.Models
{
    public class HeaderImage : IEntity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageContent { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
/*
 foreach (var image in uploadImages)
        {
            if (image.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image.ContentLength);
                }
                var headerImage = new HeaderImage
                {
                    ImageData = imageData,
                    ImageName = image.FileName,
                    IsActive = true
                };
imageRepository.AddHeaderImage(headerImage);
            }
        }*/