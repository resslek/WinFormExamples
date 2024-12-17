# WinFormExamples
Examples of my exploration of different problems that I needed to solve for larger applications.  Many were used as a training aid for new newer developers that I have worked with.

LogThreading

A sample application that uses Serilog and dependency injection to apply logging to individual threads and the overall application.  The factory pattern is used throughout for assistance with logging and winform creation.  The goal of this application is to log the start and stop of a overall process to the main logging file and each thread to write out its data in individual task folders.