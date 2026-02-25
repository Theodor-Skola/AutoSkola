using System.Text;

class ContactInfo
{
    public string mail {get; set;}
    public string förNamn {get; set;}
    public string efterNamn {get; set;}

    public string skolaFrån {get; set;}
    public bool ärKund {get; set;} = false;

    public string meddelande {get; set;}


    public string Serialize()
    {
        mail = mail.Replace(';', ',');
        förNamn = förNamn.Replace(';', ',');
        efterNamn = efterNamn.Replace(';', ',');

        skolaFrån = skolaFrån.Replace(';', ',');
        meddelande = meddelande.Replace(';', ',').Replace("\r\n", "\t");

        return $"{mail};{förNamn};{efterNamn};{ärKund};{skolaFrån};{meddelande}\n";

    }
}