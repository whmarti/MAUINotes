using UIKit;

namespace MauiNotes.views;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePage()
    {
        InitializeComponent();
        //if (File.Exists(_fileName))
        //    TextEditor.Text = File.ReadAllText(_fileName);
        string appDataPath = FileSystem.AppDataDirectory;
        string randomeFile = $"{Path.GetRandomFileName()}.notes.txt";

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

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        TextEditor.Text = String.Empty;
    }
}