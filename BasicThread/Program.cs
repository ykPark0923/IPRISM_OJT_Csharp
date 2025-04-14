using System;
using System.Threading; // Thread 클래스 사용을 위한 네임스페이스
using System.Security.Permissions; // (현재 코드에서 사용되지 않음, 생략 가능)
using System.IO;
using System.Threading.Tasks;

namespace BasicThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string srcFile = args[0];

            Action<object> FileCopyAction = (object state) =>
            {
                String[] paths = (String[])state;
                File.Copy(paths[0], paths[1]);

                Console.WriteLine("TaskID:{0}, ThreadID:{1}, {2} was copied to {3}", Task.CurrentId,
                    Thread.CurrentThread.ManagedThreadId, paths[0], paths[1]);
            };

            Task t1 = new Task(
                FileCopyAction, new string[] { srcFile, srcFile + ".copy1" }
                );


            Task t2 = Task.Run(() =>
            {
                FileCopyAction(new string[] { srcFile, srcFile + ".copy2" });
            });

            t1.Start();

            Task t3 = new Task(
                FileCopyAction, new string[] { srcFile, srcFile + ".copy3" }
                );

            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();
            t3.Wait();

        }
    }
}
