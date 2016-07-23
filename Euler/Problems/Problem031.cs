using System;
using System.Collections.Generic;

namespace Euler.Problems
{
    /// <summary>
    /// 
    ///     In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
    ///     
    ///     1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    ///     It is possible to make £2 in the following way:
    ///     
    ///     1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    ///     How many different ways can £2 be made using any number of coins?
    /// 
    /// 
    /// </summary>
    public class Problem031 : Problem
    {
        public const int P1 = 1;
        public const int P2 = 2;
        public const int P5 = 5;
        public const int P10 = 10;
        public const int P20 = 20;
        public const int P50 = 50;
        public const int P100 = 100;
        public const int P200 = 200;
        public const int MAX = P200;

        public override void Calculate()
        {
            WalletBank walletBank = new WalletBank();
            AddCashMoney(walletBank, new Wallet());
        }
        
        private void AddCashMoney(WalletBank walletBank, Wallet wallet)
        {
            int restValue = wallet.GetRestValue();

            if (restValue == P1) walletBank.Add(new Wallet(wallet, Wallet.Coin.P1));
            else if (restValue == P2) walletBank.Add(new Wallet(wallet, Wallet.Coin.P2));
            else if (restValue == P5) walletBank.Add(new Wallet(wallet, Wallet.Coin.P5));
            else if (restValue == P10) walletBank.Add(new Wallet(wallet, Wallet.Coin.P10));
            else if (restValue == P20) walletBank.Add(new Wallet(wallet, Wallet.Coin.P20));
            else if (restValue == P50) walletBank.Add(new Wallet(wallet, Wallet.Coin.P50));
            else if (restValue == P100) walletBank.Add(new Wallet(wallet, Wallet.Coin.P100));
            else if (restValue == P200) walletBank.Add(new Wallet(wallet, Wallet.Coin.P200));

            if (restValue > P100 && wallet.HasNoLowerCoinsThan(Wallet.Coin.P100)) AddCashMoney(walletBank, new Wallet(wallet, Wallet.Coin.P100));
            if (restValue > P50 && wallet.HasNoLowerCoinsThan(Wallet.Coin.P50)) AddCashMoney(walletBank, new Wallet(wallet, Wallet.Coin.P50));
            if (restValue > P20 && wallet.HasNoLowerCoinsThan(Wallet.Coin.P20)) AddCashMoney(walletBank, new Wallet(wallet, Wallet.Coin.P20));
            if (restValue > P10 && wallet.HasNoLowerCoinsThan(Wallet.Coin.P10)) AddCashMoney(walletBank, new Wallet(wallet, Wallet.Coin.P10));
            if (restValue > P5 && wallet.HasNoLowerCoinsThan(Wallet.Coin.P5)) AddCashMoney(walletBank, new Wallet(wallet, Wallet.Coin.P5));
            if (restValue > P2 && wallet.HasNoLowerCoinsThan(Wallet.Coin.P2)) AddCashMoney(walletBank, new Wallet(wallet, Wallet.Coin.P2));
            if (restValue > P1 && wallet.HasNoLowerCoinsThan(Wallet.Coin.P1)) AddCashMoney(walletBank, new Wallet(wallet, Wallet.Coin.P1));
        }
    }

    public class WalletBank
    {
        List<Wallet> walletBank;
        public WalletBank()
        {
            walletBank = new List<Wallet>();
        }

        public void Add(Wallet wallet)
        {
            Console.Write("\rCount: {0}", walletBank.Count);
            foreach (Wallet w in walletBank)
            {
                if (w.IsTheSame(wallet)) return;
            }
            walletBank.Add(wallet);
        }

        public object Count()
        {
            return walletBank.Count;
        }
    }

    public class Wallet
    {
        public int P1 { private set; get; }
        public int P2 { private set; get; }
        public int P5 { private set; get; }
        public int P10 { private set; get; }
        public int P20 { private set; get; }
        public int P50 { private set; get; }
        public int P100 { private set; get; }
        public int P200 { private set; get; }

        public enum Coin { P1, P2, P5, P10, P20, P50, P100, P200 };

        public Wallet()
        {
        }

        public void AddCoin(Coin c)
        {
            switch (c)
            {
                case Coin.P1:
                    {
                        P1++;
                        return;
                    }
                case Coin.P2:
                    {
                        P2++;
                        return;
                    }
                case Coin.P5:
                    {
                        P5++;
                        return;
                    }
                case Coin.P10:
                    {
                        P10++;
                        return;
                    }
                case Coin.P20:
                    {
                        P20++;
                        return;
                    }
                case Coin.P50:
                    {
                        P50++;
                        return;
                    }
                case Coin.P100:
                    {
                        P100++;
                        return;
                    }
                case Coin.P200:
                    {
                        P200++;
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        public bool HasNoLowerCoinsThan(Coin c)
        {
            switch (c)
            {
                case Coin.P1:
                    {
                        return true;
                    }
                case Coin.P2:
                    {
                        return (P1 == 0);
                    }
                case Coin.P5:
                    {
                        return (P1 == 0 && P2 == 0);
                    }
                case Coin.P10:
                    {
                        return (P1 == 0 && P2 == 0 && P5 == 0);
                    }
                case Coin.P20:
                    {
                        return (P1 == 0 && P2 == 0 && P5 == 0 && P10 == 0);
                    }
                case Coin.P50:
                    {
                        return (P1 == 0 && P2 == 0 && P5 == 0 && P10 == 0 && P20 == 0);
                    }
                case Coin.P100:
                    {
                        return (P1 == 0 && P2 == 0 && P5 == 0 && P10 == 0 && P20 == 0 && P50 == 0);
                    }
                case Coin.P200:
                    {
                        return (P1 == 0 && P2 == 0 && P5 == 0 && P10 == 0 && P20 == 0 && P50 == 0 && P100 == 0);
                    }
                default:
                    {
                        return false;//??
                    }
            }
        }

        public Wallet(Wallet oldWallet, Coin c)
        {
            P1 = oldWallet.P1;
            P2 = oldWallet.P2;
            P5 = oldWallet.P5;
            P10 = oldWallet.P10;
            P20 = oldWallet.P20;
            P50 = oldWallet.P50;
            P100 = oldWallet.P100;
            P200 = oldWallet.P200;

            AddCoin(c);
        }

        public bool IsTheSame(Wallet otherWallet)
        {
            return (P1 == otherWallet.P1 && P2 == otherWallet.P2 && P5 == otherWallet.P5 && P10 == otherWallet.P10 && P20 == otherWallet.P20 && P50 == otherWallet.P50 && P100 == otherWallet.P100 && P200 == otherWallet.P200);
        }

        public int GetRestValue()
        {
            return Problem031.MAX - (P1 * 1 + P2 * 2 + P5 * 5 + P10 * 10 + P20 * 20 + P50 * 50 + P100 * 100 + P200 * 200);
        }
    }
}
