

interface IPilha
{
    // Metodos da piha Preta
    object TopPreto();
    object PopPreto();
    void PushPreto(object o);
    bool IsEmptyPreto(); 
    int SizePreto();

    // Metodos da Pilha Vermelha
    object TopVermelho();
    object PopVermelho();
    void PushVermelho(object o);
    bool IsEmptyVermelho(); 
    int SizeVermelho();

    // Métodos Gerais
    void VerificarPilhaCheia();
}