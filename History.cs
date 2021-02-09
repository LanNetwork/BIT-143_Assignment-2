using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Helpdesk
{
    class History : PageList
    {
        PageNode current = new PageNode();

        //TODOne: PrintAll(): Work out location handling. basic: start at first, while loop checking if Next is null.
        public void PrintAll()
        {
            if (first == null) // manual edgecase, if no history has been generated, print empty history log
            {
                Console.Out.WriteLine("History:");
                Console.Out.WriteLine("Previously visited pages:");
                Console.Out.WriteLine("Pages in your \"future\":");
                return;
            }

            bool before = true; //variable to tell if current page has been passed
            Console.Out.WriteLine("History:");
            Console.Out.WriteLine("Previously visited pages:");

            if (current == first) // edge case, only 1 page in history
            {
                before = false;
            }

            PageNode loopOn = first;
            while (before) // print previously visited pages
            {
                Console.Out.WriteLine(loopOn.PageName);
                loopOn = loopOn.Next;
                if (loopOn == current)
                {
                    before = false;
                }
            }

            Console.Out.WriteLine(loopOn.PageName); //print current page

            Console.Out.WriteLine("Pages in your \"future\":");
            while (loopOn.Next != null) // print future pages
            {
                loopOn = loopOn.Next;
                Console.Out.WriteLine(loopOn.PageName);
            }
        }

        //TODOne: MoveBackwards(): start at first, while loop until Next is current. Then set current to the node you're on in the loop.
        // I don't understand why we aren't using doubly linked lists. The concept is literally just the natural extension of a regular LL.
        public void MoveBackwards()
        {
            if (current == null || first == null) // edge cases, if there's nothing in the lit, or if current is null for some reason.
            {
                return;
            }

            PageNode loopOn = first;
            while (loopOn.Next != current) // loop through list until the Next value of our loop node is == our current node.
            {
                if (loopOn == current) // edge case, only 1 result.
                {
                    return;
                }
                if (loopOn.Next != null)
                {
                    loopOn = loopOn.Next;
                }
                else
                {
                    current = loopOn; // set current node to 1 back from itself
                    break;
                }
            }

            current = loopOn; // set current node to 1 back from itself
        }

        //TODOne: MoveForwards(): if current.Next != null, set current = current.Next
        public void MoveForwards()
        {
            if (current.Next != null) // see function description
            {
                current = current.Next;
            }
        }

        //TODOne: VisitPage(): Set current.Next = new Node, then set current = current.Next (you could use MoveForward() here, but feels weird)
        public void VisitPage(string desc)
        {
            if (first == null) // edge case, generating first new page.
            {
                first = new PageNode(desc);
                current = first;
            }
            else //otherwise, just add a new node to the end.
            {
                current.Next = new PageNode(desc);
                current = current.Next;
            }
        }
    }
}