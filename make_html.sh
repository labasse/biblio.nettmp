#!/bin/sh

EXE="${1:-FlatBiblio}"

cat data/_liste.txt data/fg67hIOrf.txt | $EXE > wwwroot/fg67hIOrf.html
cat data/_liste.txt data/rt25TYuy0.txt | $EXE > wwwroot/rt25TYuy0.html
