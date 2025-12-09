namespace AspNetCoreLearning.FileUploading.Model
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }
    }
    public enum FileType
    {
        PDF = 1,
        DOCX = 2,
        Excel = 3
    }
}
