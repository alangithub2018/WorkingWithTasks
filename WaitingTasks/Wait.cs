namespace WaitingTasks {
    public static class Wait {
        public static void Wait1() {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() => {
                Console.WriteLine("I take 5 seconds");
                for (int i = 0; i < 5; i++) {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("I'm done");
            }, token);
            t.Start();

            Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            Task.WaitAll(new[] {t, t2}, 4000, token);
            
            Console.WriteLine($"Task t status is {t.Status}");
            Console.WriteLine($"Task t2 status is {t2.Status}");

            Console.WriteLine("Main program done");
            Console.ReadKey();
        }
    }
}