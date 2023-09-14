class Projeto
{
    public Projeto(string id, string dataInicio, string dataConclusao, string lider)
    {
        this.id = id;
        this.dataInicio = dataInicio;
        this.dataConclusao = dataConclusao;
        this.lider = lider;
    }

    public string id { get; set; }
    public string dataInicio { get; set; }
    public string dataConclusao { get; set; }
    public string lider { get; set; }
    
}