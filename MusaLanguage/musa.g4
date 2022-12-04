grammar musa; 

musa : (comando)+ EOF;

comando :  (asignacion) | (condicion) | (impresion) | (loopFor) | loopWhile;

loopFor : FOR SPAR asignacion (COMP|BOOLEAN) INSEP 
        (ID SUM NUM|ID DIF NUM|ID SUM SUM|ID DIF DIF)EPAR
        SBR comando+ EBR
;

loopWhile: WHILE SEP+ SPAR (COMP | BOOLEAN) EPAR SBR comando+ EBR;

condicion : IF SEP COMP SEP+ THEN SEP* SBR 
(comando)+ EBR (else)? ;

else : ELSE SBR (comando)+ EBR ;

impresion : IMP SPAR (SENT|ID) EPAR INSEP
;

asignacion : ID ASSIGN expresion INSEP #int
            | ID ASSIGN SENT #string
           ;

expresion : expresion op=(SUM|DIF) termino #sumORes
          | termino                        #terminoSolo
          ;

termino : termino op=(MULT|DIV) factor #mulODiv
        | factor                      #factorSolo
        ;

factor : NUM+                      #numero
       | ID                       #identificador
       | SPAR expresion EPAR      #subexpresion
       ;

FOR : 'for'; 
WHILE : 'while';
IMP : 'monta' | 'MONTA';
BOOLEAN : 'TRUE' | 'FALSE' | 'true' | 'false' ;
IF : 'if' ;
THEN : 'then' ;
ELSE : 'else' ;
NUM : [0-9] ;
COMP : (((ID|NUM+) OP (ID|NUM+)));
ID : WORD NUM*;
SENT : QUOTE WORD+ (SEP WORD)* QUOTE | QUOTE NUM+ QUOTE ;
WORD : [A-Za-z]+ ;
COMA : ',';
QUOTE : '"';
SUM : '+' ; 
DIF : '-' ;
DIV : '/' ;
MULT : '*' ;
ASSIGN : '<-';
INSEP : ';' ;
SBR : '[' ; 
EBR : ']' ;
SPAR : '(' ;
EPAR : ')' ;
SEP : ' ';
OP : '==' | '>' | '<' | '>=' | '<=' | '<>' ;




WS : '\n' -> skip ;
SK2 : '\r' -> skip;
SK3 : '    '+ -> skip;