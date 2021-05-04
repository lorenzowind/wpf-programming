namespace GenericCRUD.ViewModels
{
    public class DialogResult
    {
        #region Constructors
        public DialogResult(bool? result, string fileName)
        {
            Result = result;
            FileName = fileName;
        }
        #endregion

        #region Properties
        public bool? Result { get; }
        public string FileName { get; }
        #endregion
    }
}
