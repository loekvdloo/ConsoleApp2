namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INotificationService emailService =
                new EmailNotificationService();

            INotificationService smsService =
                new SmsNotificationService();

            INotificationService pushService =
                new PushNotificationService();


            emailService.Send(
                "student@school.nl",
                "Je nieuwe rooster staat klaar."
            );

            smsService.Send(
                "0612345678",
                "Je les begint over 15 minuten."
            );

            pushService.Send(
                "student123",
                "Er staat nieuwe feedback voor je klaar."
            );



            NotificationManager manager = new NotificationManager(emailService);

            manager.Send(
                "student@school.nl",
                "Je nieuwe rooster staat klaar."
            );

            manager.SetNotificationService(smsService);
            manager.Send(
                "0612345678",
                "Je les begint over 15 minuten."
            );

            manager.SetNotificationService(pushService);
            manager.Send(
                "student123",
                "Er staat nieuwe feedback voor je klaar."
            );


            INotificationService whatsAppService =
                new WhatsAppNotificationAdapter(new ExternalWhatsAppLibrary.WhatsAppClient());

            manager.SetNotificationService(whatsAppService);
            manager.Send(
                "0612345678",
                "Je huiswerk is beoordeeld."
            );


            Console.ReadLine();
        }
    }
}