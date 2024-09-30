namespace Adesso.WorldLeague.Application.Draws.Inputs;

public class CreateDrawCommandInput
{
    public string OperatorFirstName { get; set; }

    public string OperatorLastName { get; set; }
    
    public int GroupCount { get; set; }
}