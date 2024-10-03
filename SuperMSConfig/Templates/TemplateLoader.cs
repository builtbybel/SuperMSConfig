using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Templates;

public class TemplateLoader
{
    // Deserializes the template JSON file into a list of HabitTemplate objects
    public TemplateFile LoadTemplateFile(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);

            // Deserialize the full template file (with Header and Entries)
            var templateFile = JsonConvert.DeserializeObject<TemplateFile>(json);

            if (templateFile == null)
            {
                throw new InvalidDataException("Deserialized JSON data is null.");
            }

            return templateFile;
        }
        catch (JsonException ex)
        {
            throw new InvalidDataException("Error parsing JSON data. " + ex.Message, ex);
        }
        catch (IOException ex)
        {
            throw new IOException("Error reading JSON file. " + ex.Message, ex);
        }
    }
}

public class TemplateFile
{
    public string Header { get; set; }
    public List<HabitTemplate> Entries { get; set; }
}