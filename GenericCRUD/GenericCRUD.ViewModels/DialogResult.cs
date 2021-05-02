namespace GenericCRUD.ViewModels
{
    public class DialogResult
    {
        public DialogResult(bool? result, string fileName)
        {
            Result = result;
            FileName = fileName;
        }

        public bool? Result { get; }
        public string FileName { get; }
    }
}
