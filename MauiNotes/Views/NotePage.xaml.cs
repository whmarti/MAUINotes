namespace MauiNotes.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class NotePage : ContentPage
{
    //string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public string ItemId { set { LoadNote(value); } }
    public NotePage()
    {
        InitializeComponent();
        //if (File.Exists(_fileName))
        //    TextEditor.Text = File.ReadAllText(_fileName);
        string appDataPath = @"D:\";// FileSystem.AppDataDirectory;
        string randomeFile = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(appDataPath,randomeFile));

    }
    private void LoadNote(string fileName)
    {
        Models.Note note = new Models.Note();
        note.FileName = fileName;
        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(fileName);
            note.Text = File.ReadAllText(fileName);
        }
        BindingContext = note;

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.FileName, TextEditor.Text);
        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            //Delete the file
            if (File.Exists(note.FileName))
                File.Delete(note.FileName);
        }
        await Shell.Current.GoToAsync("..");
    }
}