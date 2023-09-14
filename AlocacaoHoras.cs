class AlocacaoHoras
{
    public AlocacaoHoras(int qtdHoraPorMaquina, Maquina maquina, Projeto projeto)
    {
        this.qtdHoraPorMaquina = qtdHoraPorMaquina;
        this.maquina = maquina;
        this.projeto = projeto;
    }

    public int qtdHoraPorMaquina { get; set; }
    public Maquina  maquina { get; set; }
    public Projeto projeto { get; set; }


}