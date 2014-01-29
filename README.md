# EasyTLC
 Turn WorkBrain schedules into .ics files

## What's all this about?
It's a very simple application to scrape the shifts off of a WorkBrain schedule page and spit out an iCal (.ics) file.  You can import an .ics file into any calendar application that matters.

## Does this do anything evil, like steal my password?
No.  Nothing is saved anywhere except the .ics file you export.  You don't have to use the login fields on the form if you don't want to.

## Are you sure it doesn't do anything evil?
Yes, I'm sure.  If you don't beleive me either check the source yourself or don't use it.

## What can I do with this .ics file?
Any calendar application should be able to import it.  I've tried it with Outlook 2013 on Windows, Outlook 2010 on Mac, and Outlook.com via browser, it works fine on all of them.  You might need to just drag and drop the file onto the calendar in Outlook on Windows/Mac.

## Does this automatically sync my schedule?
No, you'll need to do this every time your schedule changes

## My schedule spans more than one month, can I do both months in one go?
No.  Do one month, close the app, then open it and do the second month.

## It's ignoring shifts that happened in the past.
This is by design.

## I clicked a button at a time it didn't make sense to click that button, and it crashed.
Only press the scrape button when there's a schedule on the screen to scrape.  Don't press the login button if you logged in manually.
