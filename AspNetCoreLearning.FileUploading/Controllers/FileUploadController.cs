using AspNetCoreLearning.FileUploading.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLearning.FileUploading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost("PostSingleFile")]
        public IActionResult UploadSingleFile(FileUploadModel fileData)
        {
            using (var stream = new MemoryStream())
            {
                fileData.FileDetails.CopyTo(stream);
                var data = stream.ToArray();
            }

            return Ok();
        }
        [HttpPost("PostMultipleFile")]
        public IActionResult UploadSingleFile(List<FileUploadModel> fileData)
        {
            foreach (FileUploadModel file in fileData)
            {
                using (var stream = new MemoryStream())
                {
                    file.FileDetails.CopyTo(stream);
                    var data = stream.ToArray();
                }
            }
            return Ok();
        }
    }
}
