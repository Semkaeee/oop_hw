public static class Program
{
    public static void Main()
    {
        var bank = new BankApi();

        bank.RegisterUser("sam");
        bank.Deposit("sam", 100);
        bank.Withdraw("sam", 30);

        System.Console.WriteLine(bank.GetBalance("sam")); //70

        bank.ArrestAccount("sam");
        bank.Withdraw("sam", 10); //арест

        System.Console.WriteLine(bank.GetBalance("sam")); //70
    }
}