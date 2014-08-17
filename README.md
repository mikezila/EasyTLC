# EasyTLC
Turn WorkBrain schedules into .ics files

### What's all this about?
It's a very simple application to scrape the shifts off of a WorkBrain schedule page and spit out an iCal (.ics) file.

### Does this do anything evil, like steal my password?
No.  Though you can specify your credentials, time offset, and chosen event name by making a "creds.ini" file in the same directory as the .exe.  The four lines in it should be your event name, your username, your password, and how many hours to offset your date, as either a positive (1) or negative (-1) number.

### Are you sure it doesn't do anything evil?
Yes, I'm sure.  If you don't trust me either check the source yourself or don't use it.

### What can I do with this .ics file?
Almost any calendar application should be able to import it.  I've tried it with Outlook 2013 on Windows, Outlook 2010 on Mac, and Outlook.com via a browser, it works fine on all of them.  You might need to just drag and drop the file onto the calendar in Outlook on Windows/Mac.

### Does this automatically sync my schedule?
No, you'll need to do this every time your schedule changes

### My schedule spans more than one month, can I do both months in one go?
No.  Do one month, close the app, then open it and do the second month.

### Does this handle time zones?
Not directly.  You can shift the resulting calendar events forward or backward using the time shift box on the form, but it doesn't embed any timezone information in the calendar.  I do it this way because time zone handling is complicated and relies on your clients having their time zone configured correctly, which isn't always the case.

### It's ignoring shifts that happened in the past.
This is by design.

### I clicked a button at a time it didn't make sense to click that button, and it crashed.
Only press the scrape button when there's a schedule on the screen to scrape.  Don't press the login button if you logged in manually.
