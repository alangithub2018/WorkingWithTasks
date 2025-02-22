namespace CancellationTasks {
    public static class CancelTask {
        public static void Cancel1() {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            token.Register(() => Console.WriteLine("Cancellation has been requested"));

            var t = new Task(() => {
                int i = 0;
                while(true) {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                }
            }, token);
            t.Start();

            Task.Factory.StartNew(() => {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle released, thus cancellation was requested");
            });

            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Main program done");
            Console.ReadKey();
        }

        public static void Cancel2() {
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
                planned.Token, preventative.Token, emergency.Token);

            Task.Factory.StartNew(() => {
                int i = 0;
                while(true) {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep(1000);
                }
            }, paranoid.Token);

            Console.ReadKey();
            emergency.Cancel();
            
            Console.WriteLine("Main program done");
            Console.ReadKey();
        }

        public static void BoomSample() {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() => {
                Console.WriteLine("Press any key to disarm: you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled ? "Bomb disarmed" : "BOOM!!!");
            }, token);
            t.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.ReadKey();
            Console.WriteLine("Main program done");
            Console.ReadKey();
        }
    }
}