namespace CreatingTasks {
    public static class CreateTask {
        public static void write(char c) {
            int i = 1000;
            while (i-- > 0) {
                Console.Write(c);
            }
        }

        public static void write(object c) {
            int i = 1000;
            while (i-- > 0) {
                Console.Write(c);
            }
        }

        public static int TextLength(object o) {
            Console.WriteLine($"Task with id {Task.CurrentId} processing object {o}...");
            return o.ToString()!.Length;
        }

        public static void Create() {
            Task.Factory.StartNew(() => write('.'));

            var t = new Task(() => write('!'));
            t.Start();

            write('?');

            Task t2 = new Task(write!, "hello");
            t2.Start();

            Task.Factory.StartNew(write!, 123);

            string text1 = "testing", text2 = "this";
            var task1 = new Task<int>(TextLength!, text1);
            task1.Start();

            Task<int> task2 = Task.Factory.StartNew<int>(TextLength!, text2);

            Console.WriteLine($"Length of '{text1}' is {task1.Result}");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}");
        }
    }
}
