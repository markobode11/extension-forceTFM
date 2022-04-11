namespace UpgradeAssistant.Extension.ForceTFM;

public record TfmOptionMap
{
    public string Current { get; set; }
    
    public string Preview { get; set; }
    
    public string LTS { get; set; }
}