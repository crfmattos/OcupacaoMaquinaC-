class Maquina
{
    public Maquina(string nome, int limiteHoras, double valorMaquina)
    {
        this.nome = nome;
        this.limiteHoras = limiteHoras;
        this.valorMaquina = valorMaquina;
        this.valorHora = valorHora;
    }
    public string nome { get; set; }
    public double limiteHoras { get; set; }
    public double valorMaquina { get; set; }
    private double valorHora { get; set; }
    

    public double calcularValorHora()
    {
        this.valorHora = ((this.valorMaquina * 0.10)/365)/24; 
        return valorHora;
    }
}


