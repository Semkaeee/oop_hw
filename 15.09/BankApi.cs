using System.Collections.Generic;

public class BankApi
{
    private readonly Dictionary<string, Account> accounts = new Dictionary<string, Account>();

    public bool RegisterUser(string userName)
    {
        lock (accounts)
        {
            if (accounts.ContainsKey(userName))
                return false;

            accounts[userName] = new Account();
            return true;
        }
    }

    public bool Deposit(string userName, decimal amount)
    {
        lock (accounts)
        {
            if (!accounts.TryGetValue(userName, out var account))
                return false;

            return account.Deposit(amount);
        }
    }

    public bool Withdraw(string userName, decimal amount)
    {
        lock (accounts)
        {
            if (!accounts.TryGetValue(userName, out var account))
                return false;

            return account.Withdraw(amount);
        }
    }

    public decimal? GetBalance(string userName)
    {
        lock (accounts)
        {
            if (!accounts.TryGetValue(userName, out var account))
                return null;

            return account.Balance;
        }
    }

    public bool ArrestAccount(string userName)
    {
        lock (accounts)
        {
            if (!accounts.TryGetValue(userName, out var account))
                return false;

            account.Arrest();
            return true;
        }
    }

    public bool IsAccountArrested(string userName)
    {
        lock (accounts)
        {
            if (!accounts.TryGetValue(userName, out var account))
                return false;

            return account.IsArrested;
        }
    }

    private class Account
    {
        public decimal Balance { get; private set; }

        public bool IsArrested { get; private set; }

        public bool Deposit(decimal amount)
        {
            if (IsArrested)
                return false;

            Balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (IsArrested)
                return false;

            if (Balance < amount)
                return false;

            Balance -= amount;
            return true;
        }

        public void Arrest()
        {
            IsArrested = true;
        }
    }
}